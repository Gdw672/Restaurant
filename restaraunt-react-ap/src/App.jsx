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
                <Route path="/" element={<Admin />} />
                <Route path="/Admin" element={<Admin />} />
                <Route path="/Cook" element={<Cook />} />
                <Route path="/Waiter" element={<Waiter />} />
            </Routes>
        </Router>
    );
}

export default App;
