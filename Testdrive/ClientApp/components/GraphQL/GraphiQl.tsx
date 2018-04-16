import * as React from 'react';
import graphCall from '../../functions/GraphCall';
import GraphiQL from 'graphiql';

const GraphiQl = () => <div className="h-100 row"><GraphiQL fetcher={graphCall} /></div>;
export default GraphiQl;