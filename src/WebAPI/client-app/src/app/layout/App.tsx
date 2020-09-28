import React from 'react';
import './App.scss';
import { Navbar } from '../../components';
import { OccurrencesScreen } from "../../screens";

const App = () => {
  return (
      <div>
        <Navbar />
        <div id="wrapper-main">
            <OccurrencesScreen />
        </div>
      </div>
  );
}

export default App;
