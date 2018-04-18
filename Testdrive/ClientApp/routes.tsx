import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import { CustomerDashboard } from './components/Customers/CustomerDashboard';
import GraphiQl from './components/GraphQL/GraphiQl';
import { TestdriveOverview } from './components/Testdrive/TestdriveOverview';

export const routes = <Layout>
	                      <Route exact path="/" component={Home}/>
	                      <Route exact path="/customers" component={CustomerDashboard}/>
	                      <Route exact path="/graphiql" component={GraphiQl}/>
	                      <Route exact path="/testdrives/overview" component={TestdriveOverview}/>
                      </Layout>;
