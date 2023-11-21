import { BrowserRouter, Routes, Route } from "react-router-dom";
import ShowList from "./component/ShowList";
import Login from "./component/Login";

const App = () => {
    return (
        <BrowserRouter>
                <div className="row">
                    <div className="col-2" style={{ padding: "0px" }}>

                    </div>
                    <div className="col-8 topbar">
                        
                    </div>
                    <div className="col-2 topbar" style={{ justifyContent: "center !important", padding: "0px", textAlign: "center" }}>
                    </div>
                </div>
                <Routes>
                    <Route path="/showList/*" element={<ShowList />} />
                    <Route path="/login" element={<Login />} />
                </Routes>
        </BrowserRouter >
    );
};

export default App;
