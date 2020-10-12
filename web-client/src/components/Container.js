import React, { useContext, useEffect } from "react";
import { OfficeContext } from "../app/context/officeContext";
import { OfficeItem } from "./office/OfficeItem";


export const Container = ({ searchTerm }) => {
  const { offices, runSearch } = useContext(OfficeContext);
  useEffect(() => {
    runSearch(searchTerm);
    // eslint-disable-next-line
  }, [searchTerm]);

  return (
    <section id="list-office">
      <div className="container">
        <div className="row">
        <div class="list-group mx-auto">
          {offices.map(office => (
              <OfficeItem office={office} />
          )) }
           </div>
        </div>
      </div>
    </section>
  );
};
