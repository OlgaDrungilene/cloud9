import "./BookingCard.css";

export default function BookingCard({
  booking,
  onAssignClick,
  onUnassignClick,
}) {
  const hasTable = booking.table !== null;

  return (
    <div className="booking-card">
      <div className="booking-card-content">
        <h3>{booking.fullName}</h3>
        <p>
          {new Date(booking.bookingTime).toLocaleString("sv-SE", {
            dateStyle: "short",
            timeStyle: "short",
          })}{" "}
          — {booking.persons} persons
        </p>
        <p>Email: {booking.email}</p>
        <p>Status: {hasTable ? "✅ Assigned" : "❌ Not assigned"}</p>
        {booking.notes && (
          <p className="booking-notes">
            📝 <em>{booking.notes}</em>
          </p>
        )}
      </div>

      <div className="booking-card-actions">
        {!hasTable && (
          <button className="assign-btn" onClick={() => onAssignClick(booking)}>
            Assign table
          </button>
        )}

        {hasTable && (
          <button
            className="unassign-btn"
            onClick={() => onUnassignClick(booking.id)}
          >
            Unassign
          </button>
        )}
      </div>
    </div>
  );
}
