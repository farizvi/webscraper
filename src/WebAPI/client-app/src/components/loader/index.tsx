import React from "react";
import ContentLoader from "react-content-loader";

const Loader = () => {
    return (
        <ContentLoader>
            <rect x="0" y="10" width="250" height="10" />
        </ContentLoader>
    );
}

export default Loader;
