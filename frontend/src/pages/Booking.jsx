import React from "react";
import BookingForm from "../components/BookingForm/BookingForm";
import "./Booking.css";

const Booking = () => {
  return (
    <div className="booking-page">
      <div className="booking-header p__cormorant">
        <h1>Reserve a Table</h1>
        <h2 className="booking-subtitle p__cormorant">Experience fine dining done right</h2>
      </div>
      <BookingForm />
    </div>
  );
};

export default Booking;
