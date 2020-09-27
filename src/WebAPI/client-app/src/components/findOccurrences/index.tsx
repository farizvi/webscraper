import React, {useContext, useState} from 'react';
import { useForm } from 'react-hook-form';
import {AppContext} from "../../app/context/appState";

interface IFormData {
    keywords: string;
    url: string;
    numberOfPages: number;
    searchEngine: string;
}

const FindOccurrences = () => {
    const { register, handleSubmit, errors } = useForm();
    const context = useContext(AppContext);
    const {isPosting, isError, postData, occurrenceCounts} = context;
    const [isSubmitting, setIsSubmitting] = useState(false);

    const onSubmit = (data: IFormData) => {
        setIsSubmitting(true);
        postData(JSON.stringify({
            'keywords': data.keywords,
            'url': data.url,
            'numberOfPages': parseInt(data.numberOfPages.toString()),
            'searchEngine': data.searchEngine
        }));
        setIsSubmitting(false);
    }

    return (
        <div id="wrapper-main">
            <div id="wrapper-grid">
                <div className="container">
                    <form>
                        <h3>Keywords</h3>
                        <input
                            type='text'
                            name='keywords'
                            ref={register({required: true})}
                        />
                        <br/>
                        { errors.keywords && (
                            <span role='alert' className='error-message'>This field is required</span>
                        )}
                        <br />
                        <h3>Url</h3>
                        <input
                            type='text'
                            name='url'
                            ref={register({required: true})}
                        />
                        <br/>
                        { errors.url && (
                            <span role='alert' className='error-message'>This field is required</span>
                        )}
                        <br />
                        <h3>Number of Pages</h3>
                        <input
                            type='text'
                            name='numberOfPages'
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[0-9]+$/i,
                                    message: 'Please enter a valid number'
                                }
                            })}
                        />
                        <br/>
                        { errors.numberOfPages && (
                            <span role='alert' className='error-message'>Please enter a valid number</span>
                        )}
                        <br />
                        <h3>Search Engine</h3>
                        <input
                            type='radio'
                            name='searchEngine'
                            value='Bing'
                            ref={register({required: true})}
                        />Bing
                        <input
                            type='radio'
                            name='searchEngine'
                            value='Google'
                            ref={register({required: true})}
                        />Google
                        <br/>
                        { errors.searchEngine && (
                            <span role='alert' className='error-message'>This field is required</span>
                        )}
                        <br />
                        {isSubmitting ?
                            (<div>Searching...</div>)
                            :
                            (<a href='/' onClick={handleSubmit(onSubmit)}>
                                <div className="button">
                                    Search
                                </div>
                            </a>)
                        }
                    </form>
                </div>
            </div>
            <br />
            <div className='results-container'>
                <h3>Search Results</h3>
                {!isPosting && !isError && <div>{occurrenceCounts}</div>}
            </div>
        </div>
    );
}

export default FindOccurrences;
