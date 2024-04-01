import {Button} from "@mui/material";
import TheatersIcon from '@mui/icons-material/Theaters';
import "./Navbar.css"

function Navbar(){
    return (
        <nav className="navbar">
            <div className="navbar-project">
                <div className="navbar-project-logo">
                    <Button variant="contained" startIcon={<TheatersIcon />} sx={{color: "white", background: "black", '&:hover': {
                            backgroundColor: 'grey',
                            color: '#white',
                        },}} size="large">
                        Moje Kino
                    </Button>
                </div>
            </div>
            <div className="navbar-buttons">
                <Button variant="text" sx={{color: "white", '&:hover': {
                        backgroundColor: 'grey',
                        color: '#white',
                    }}}>Repertuar</Button>
                <Button variant="text" sx={{color: "white", '&:hover': {
                        backgroundColor: 'grey',
                        color: '#white',
                    }}}>Cennik</Button>
                <Button variant="outlined" sx={{color: "white", borderColor: "white", '&:hover': {
                        backgroundColor: 'grey',
                        borderColor: "white"
                    }}} size="large">Konto</Button>
            </div>
        </nav>
    )
}

export default Navbar;