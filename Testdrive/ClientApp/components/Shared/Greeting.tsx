import * as React from 'react';

type GreetingProps = { style?: React.CSSProperties | undefined, css?: string, title: string, text: string };

const Greeting = (props: GreetingProps) => {
	return <div className={`text-center${props.css ? ` ${props.css}` : ''}`} style={props.style}>
		<p className="lead mb-0">{props.title}</p>
		<hr className="mt-2 mb-2" />
		<p className="mb-0">{props.text}</p>
	</div>;
}

export default Greeting;