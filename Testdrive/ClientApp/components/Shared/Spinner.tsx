import * as React from 'react';

const Spinner = (props: { class?: string, message?: string }) => {
	return <div className={props.class ? props.class : 'absolute-centered'}>
		<div className="site-loader"></div>
		{(props.message) ? <p className="lead mt-3 mb-0">{props.message}</p> : ''}
	</div>;
}

export default Spinner;