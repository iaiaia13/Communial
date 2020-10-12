import React, { useContext, useEffect } from "react";
import { OfficeItem } from "./OfficeItem";
import { OfficeContext } from "../../app/context/officeContext";

export const ListOffice = ({ searchTerm }) => {
  const { offices, runSearch } = useContext(OfficeContext);
  // useEffect(() => {
  //   runSearch(searchTerm);
  // }, [searchTerm]);

  return (
    <section id="list-office">
      <div className="container">
        <div className="row">
          <div className="list-group mx-auto">
            {offices.map(office => (
              <OfficeItem office={office} key={office.id} />
            ))}
          </div>
        </div>
      </div>
    </section>
  );
};
