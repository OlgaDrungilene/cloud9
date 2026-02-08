import { useEffect, useState } from "react";
import {
  getBookings,
  getTables,
  assignTable,
  unassignTable,
  getAvailableTablesForBooking
} from "../services/adminApi";

import BookingCard from "../components/Admin/BookingCard";
import TableCard from "../components/Admin/TableCard";

import "./Admin.css";

export default function Admin() {
  const [bookings, setBookings] = useState([]);
  const [tables, setTables] = useState([]);

  const [selectedBooking, setSelectedBooking] = useState(null);
  const [assignTables, setAssignTables] = useState(null);

  const [bookingFilter, setBookingFilter] = useState("all");
  const [tableFilter, setTableFilter] = useState("all");

  async function loadData() {
    const [bData, tData] = await Promise.all([getBookings(), getTables()]);
    setBookings(bData);
    setTables(tData);
  }

  useEffect(() => {
    loadData();
  }, []);

  async function handleAssignClick(booking) {
    setSelectedBooking(booking);

    const available =
      await getAvailableTablesForBooking(booking.id);

    setAssignTables(available);
  }
  
  async function handleAssignTable(table) {
    if (!selectedBooking) return;

    await assignTable(selectedBooking.id, table.id);

    setSelectedBooking(null);
    await loadData();
  }

  async function handleUnassign(bookingId) {
    await unassignTable(bookingId);
    await loadData(); 
  }

  function cancelAssign() {
    setSelectedBooking(null);
    setAssignTables(null);
  }

  const filteredBookings = bookings.filter((b) => {
    if (bookingFilter === "assigned") return b.table !== null;
    if (bookingFilter === "unassigned") return b.table === null;
    return true;
  });

  const filteredTables = tables.filter((t) => {
    if (tableFilter === "available") return t.isAvailable;
    if (tableFilter === "taken") return !t.isAvailable;
    return true;
  });

   const tablesToShow = assignTables || filteredTables;

  return (
    <div className="admin-page">
        <div className="admin-container">
      <h1>Admin – Tables & Bookings</h1>

      <div className="admin-section">
        <div className="admin-header-row">
          <h2>Bookings</h2>

          <select
            value={bookingFilter}
            onChange={(e) => setBookingFilter(e.target.value)}
          >
            <option value="all">All</option>
            <option value="assigned">Assigned</option>
            <option value="unassigned">Unassigned</option>
          </select>
        </div>

        <div className="booking-list">
            {filteredBookings.map((b) => (
              <BookingCard
                key={b.id}
                booking={b}
                onAssignClick={handleAssignClick}
                onUnassignClick={handleUnassign}
              />
            ))}
        </div>
      </div>

      <div className="admin-section">
        <div className="admin-header-row">
          <h2>Tables</h2>
          <select
            value={tableFilter}
            onChange={(e) => setTableFilter(e.target.value)}
          >
            <option value="all">All</option>
            <option value="available">Available</option>
            <option value="taken">Taken</option>
          </select>
        </div>

        <div className="table-list">
          {tablesToShow.map(t => (
            <TableCard
              key={t.id}
              table={t}
              onSelect={handleAssignTable}
              disabled={
                selectedBooking &&
                t.capacity < selectedBooking.persons
              }
            />
          ))}
        </div>
      </div>

      {selectedBooking && (
        <div className="assign-banner">
          <div>
            Assign table to:
            <strong> {selectedBooking.fullName}</strong>
            {" "}({selectedBooking.persons} persons)
          </div>

          <button onClick={cancelAssign}>
            Cancel
          </button>
          
        </div>
      )}
      </div>
    </div>
  );
}
