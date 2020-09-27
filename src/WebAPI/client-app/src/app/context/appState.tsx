import React, { createContext, useState } from 'react';
import {usePost} from "../hooks";

export interface IAppProvider {
    isError: boolean;
    isPosting: boolean;
    postData: any;
    occurrenceCounts: string;
}

const AppContext = createContext<IAppProvider>({
    isError: false,
    isPosting: false,
    postData: null,
    occurrenceCounts: ''
});

const AppProvider: React.FC = props => {
    const url = '/api/scraping';
    const [data, setData] = useState('');
    const [doPost, setDoPost] = useState(false);
    const [occurrenceCounts, setOccurrenceCounts] = useState('');
    const {response, isPosting, isError} = usePost(url, data, doPost);

    const postData = (data: string) => {
        setData(data);
        setDoPost(true);

        if (!isPosting && !isError && response) {
            setOccurrenceCounts(response.toString());
        }
    }

    return (
        <AppContext.Provider
            value={{
                isPosting,
                isError,
                postData,
                occurrenceCounts
            }}
        >
            {props.children}
        </AppContext.Provider>
    );
}

const AppConsumer = AppContext.Consumer;

export {
    AppConsumer,
    AppContext,
    AppProvider
}
