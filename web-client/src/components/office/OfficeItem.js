import React from "react";
import { IOfficeItem } from "../../models/OfficeItem";

export const OfficeItem = ({ office }) => {
  return (
      <a className="list-group-item list-group-item-action">
        <img className="item-img" src='../../assets/img/offices/1.jpg' alt="" />
        <div className="item-info">
          <h5 className="office-name">{office.name}</h5>
          <p className="office-address small">
          {office.address}
          </p>
          <p className="office-description">
          {office.description}
          </p>
        </div>
        <div className="item-detail">
          <div className="office-starts">
            <i className="fa fa-star"></i>
            <i className="fa fa-star"></i>
            <i className="fa fa-star"></i>
            <i className="fa fa-star-half-o"></i>
            <i className="fa fa-star-o"></i>
            <span className="office-rating">{office.star}</span>
          </div>
          <span className="office-capacity">
            <span>capacity: </span>
            <span className="office-capacity-detail">
            <span className="office-capacity-value">{office.capacity}</span>
              <i className="fa fa-user-o"></i>
            </span>
          </span>
          <span className="office-price">
        <span className="office-price-value">{office.pricepermonth}</span>
            <span className="office-price-detail">
              <span className="office-price-ccy">₫</span>
              <span className="office-price-per">/</span>
              <span className="office-price-dur">month</span>
            </span>
          </span>
        </div>
      </a>
  );
};
