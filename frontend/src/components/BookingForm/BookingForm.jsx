import React, { useState } from "react";
import "./BookingForm.css";

const BookingForm = () => {
  const [form, setForm] = useState({
    fullName: "",
    email: "",
    phone: "",
    bookingTime: "",
    persons: 1,
    notes: ""
  });

  const [status, setStatus] = useState(null);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus("loading");

    try {
      const res = await fetch("http://localhost:5077/bookings", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(form),
      });

      if (!res.ok) throw new Error("Booking failed");
      setStatus("success");
    } catch {
      setStatus("error");
    }
  };

  return (
    <form className="booking-form" onSubmit={handleSubmit}>
      <div className="form-group">
        <label className="p__cormorant">Full Name</label>
        <input name="fullName" value={form.fullName} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label className="p__cormorant">Email</label>
        <input name="email" type="email" value={form.email} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label className="p__cormorant">Phone</label>
        <input name="phone" value={form.phone} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label className="p__cormorant">Date & Time</label>
        <input name="bookingTime" type="datetime-local" value={form.bookingTime} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label className="p__cormorant">Persons</label>
        <select name="persons" value={form.persons} onChange={handleChange}>
          {Array.from({ length: 10 }, (_, i) => i + 1).map(n => <option key={n} value={n}>{n}</option>)}
        </select>
      </div>

      <div className="form-group">
        <label className="p__cormorant">Notes (optional)</label>
        <textarea name="notes" value={form.notes} onChange={handleChange} />
      </div>

      <section className="menu-section p__cormorant">
        <button type="submit" className="custom__button" disabled={status === "loading"}>
          {status === "loading" ? "Submitting..." : "Book Now"}
        </button>
      </section>
       
      {status === "success" && <p className="status success">Booking confirmed! 🎉</p>}
      {status === "error" && <p className="status error">Something went wrong.</p>}
    </form>
  );
};

export default BookingForm;
