import "./TableCard.css";

export default function TableCard({ table, onSelect, disabled }) {
    const stateClass = disabled
    ? "disabled"
    : table.isAvailable
    ? "available"
    : "taken";

  return (
    <div
      className={`table-card ${stateClass}`}
      onClick={() => !disabled && table.isAvailable && onSelect(table)}
    >
        
      <h3>Table #{table.id}</h3>
      <p>Capacity: {table.capacity}</p>

      {table.isAvailable ? (
        <p className="status available">🟢 Available</p>
      ) : (
         <>
          <p className="status taken">🔴 Taken</p>

          {table.currentBooking && (
            <p className="current-booking">
              {table.currentBooking.fullName} <br />
              {new Date(table.currentBooking.bookingTime).toLocaleDateString()}{" "}
              {new Date(table.currentBooking.bookingTime).toLocaleTimeString([], {
                hour: "2-digit",
                minute: "2-digit",
              })}
            </p>
          )}
        </>
      )}
    </div>
  );
}
