const BASE_URL = "http://localhost:5077";

export async function getBookings() {
  const res = await fetch(`${BASE_URL}/bookings`);
  return res.json();
}

export async function getTables() {
  const res = await fetch(`${BASE_URL}/admin/tables`);
  return res.json();
}

export async function assignTable(bookingId, tableId) {
  const res = await fetch(
    `${BASE_URL}/admin/bookings/${bookingId}/assign-table?tableId=${tableId}`,
    {
      method: "PATCH",
    },
  );

  return res.json();
}

export async function unassignTable(bookingId) {
  const res = await fetch(
    `${BASE_URL}/admin/bookings/${bookingId}/unassign-table`,
    { method: "PATCH" },
  );

  if (!res.ok) throw new Error("Failed to unassign table");
  return res.json();
}

export async function getAvailableTablesForBooking(bookingId) {
  const res = await fetch(
    `${BASE_URL}/admin/tables/available-for-booking/${bookingId}`
  );
  return res.json();
}
