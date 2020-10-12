import React, { createContext, useState } from "react";
import agent from '../api/agent';

export const OfficeContext = createContext();

const OfficeContextProvider = props => {
  const [offices, setOffices] = useState([]);

  const runSearch = async (query) => {
    try {
      const offices = await agent.Office.search(query);
      setOffices(offices);
    } catch (error) {
      console.log(
        "Encountered an error with fetching and parsing data",
        error
      );
    }
  };
  return (
    <OfficeContext.Provider value={{ offices, runSearch }}>
      {props.children}
    </OfficeContext.Provider>
  );
};

export default OfficeContextProvider;
