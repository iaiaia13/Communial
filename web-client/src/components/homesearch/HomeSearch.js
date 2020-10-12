import React, { useContext, useState } from "react";
import { OfficeContext } from "../../app/context/officeContext";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import DatePicker from 'react-date-picker';
import "react-datetime/css/react-datetime.css";

const HomeSearch = () => {
  const { offices, runSearch } = useContext(OfficeContext);
  const [fromDate, onChangeFromDate] = useState(new Date());
  const [toDate, onChangeToDate] = useState(new Date());
  const { register, handleSubmit } = useForm();

  function onSubmit(data, e) {
    e.preventDefault();
    runSearch(data);
  }

  return (
    <header className="masthead">
      <div className="header-slide"></div>
      <div className="header-content">
        <form onSubmit={handleSubmit(onSubmit)}
          className="search-form"
        >
          <div className="header-content-inner">
            <h1 id="homeHeading">WORKSPACE FOR ALL</h1>
            <hr />
            <p>Look for your ideal workspace</p>
          </div>
          <ul id="search-header" className="nav nav-tabs nav-fill m-2">
            <li className="nav-item">
              <Link to={`/communal`} className="nav-link active">COMMUNAL</Link>
            </li>
            <li className="nav-item">
              <Link to={`/standard`} className="nav-link">STANDARD</Link>
            </li>
            <li className="nav-item">
              <Link to={`/metting`} className="nav-link">MEETING</Link>
            </li>
            <li className="nav-item">
              <Link to={`/virtual`} className="nav-link">VIRTUAL</Link>
            </li>
          </ul>

          <div id="search-body" className="container">
            <div className="row">
              <div className="col-lg-6 form-group mx-auto">
                <input
                  id="search-name"
                  className="form-control"
                  type="text"
                  placeholder="You might know the name or location"
                  name="address"
                  ref={register}
                />
              </div>
            </div>
            <div className="row">
              <div className="col-lg-6 form-group form-inline mx-auto">
                <input
                  placeholder="Price from"
                  type="text"
                  name="pricefrom"
                  className="form-control col-6"
                  ref={register}
                />
                <input
                  placeholder="Price to"                  
                  type="text"
                  name="priceto"
                  className="form-control col-6"
                  ref={register}
                />
              </div>
            </div>
            <div className="row">
              <div className="col-lg-6 form-group mx-auto">
                <input
                  id="search-size"
                  className="form-control"
                  type="text"
                  placeholder="Your team of 5-10 members"
                  name="strcapacity"
                  ref={register}
                />
              </div>
            </div>
          </div>

          <button
            className="btn btn-primary btn-xl js-scroll-trigger"
            type="submit"
          >
            SEARCH
            </button>
        </form>
      </div>
      <div className="container"></div>
    </header>
  );
};

export default HomeSearch;
