import { useEffect, useState } from 'react';
import axios from 'axios';

const usePost = (url: string, data: string, run: boolean)  => {
    const [response, setResponse] = useState({});
    const [isPosting, setPosting] = useState(true);
    const [isError, setError] = useState(false);

    useEffect(() => {
        let mounted = true;
        const abortController = new AbortController();
        const signal = abortController.signal;

        const config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };

        if (run && mounted) {
            const postData = async () => {
                try {
                    setPosting(true);
                    const response = await axios.post(url, data, config);
                    if (response.status === 200 && !signal.aborted) {
                        setResponse(response.data);
                    }
                } catch (err) {
                    console.log(err);
                    if (!signal.aborted) {
                        setResponse(err);
                        setError(true);
                    }
                } finally {
                    if (!signal.aborted) {
                        setPosting(false);
                    }
                }
            };

            postData();

            return () => {
                mounted = false;
                abortController.abort();
            };
        }
    }, [run, url, data]);

    return { response, isPosting, isError };
}

export default usePost;
