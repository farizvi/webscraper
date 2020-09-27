import React from 'react';
import {FindOccurrences, Header} from "../../components";

const OccurrencesScreen = () => {
    return (
        <div>
            <Header title="Web Scraper" />
            <FindOccurrences />
        </div>
    );
}

export default OccurrencesScreen;
