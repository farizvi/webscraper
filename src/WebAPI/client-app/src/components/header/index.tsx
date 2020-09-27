import React from 'react';
import '../../app/layout/App.scss';

interface IHeaderProps {
    title: string;
}

const Header = (props: IHeaderProps) => {
    return (
        <div className="header">
            <h1>{props.title}</h1>
        </div>
    );
};

export default Header;
