import * as React from 'react';
import NavigationBar from './Shared/Navbar';
import { actionCreators } from '../store/misc/Navbar';

export const Layout = ({ children }: { children?: React.ReactNode }) => {
    return <div id="site">
               <NavigationBar toggle={actionCreators.toggle}/>
               <div id="page-content">
                   {children}
               </div>
           </div>;
}