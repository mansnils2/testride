import * as React from 'react';
import { graphCall } from '../../functions/GraphCall';
import GraphiQL from 'graphiql';

const GraphiQl = () => <GraphiQL fetcher={graphCall} />;
export default GraphiQl;