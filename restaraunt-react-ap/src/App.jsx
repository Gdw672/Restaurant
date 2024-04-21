import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Authentication from "./Scripts/Authentication";
import Admin from "./RolePage/Admin";
import Cook from "./RolePage/Cook";
import Waiter from "./RolePage/Waiter";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Cook />} />
                <Route path="/Admin" element={<Admin />} />
                <Route path="/Cook" element={<Authentication />} />
                <Route path="/Waiter" element={<Waiter />} />
            </Routes>
        </Router>
    );
}

export default App;
