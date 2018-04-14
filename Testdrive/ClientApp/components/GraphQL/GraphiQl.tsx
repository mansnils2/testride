﻿import * as React from 'react';
import { graphCall } from '../../functions/GraphCall';
import GraphiQL from 'graphiql';

const GraphiQl = () => <div className="h-100"><GraphiQL fetcher={graphCall} /></div>;
export default GraphiQl;