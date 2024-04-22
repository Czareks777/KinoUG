import "./app.css";
// import Carousel from "./components/Carousel/Carousel.jsx";
// import { slides } from "./data/carouselData.json";
// import { hits } from "./data/hitsData.json";
// import { upcoming } from "./data/upcomingData.json";
import Navbar from "./components/Navbar/Navbar.jsx";
import PriceList from "./components/PriceList/PriceList.jsx";
// import FilmMenu from "./components/Film/film.jsx";

function App() {
  return (
    <>
      <Navbar />
      <PriceList />
      {/*<Carousel data={slides} />*/}
      {/*<FilmMenu hits={hits} upcoming={upcoming} />*/}
    </>
  );
}

export default App;
