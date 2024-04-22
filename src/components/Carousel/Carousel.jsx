import { useEffect, useState } from "react";
import "./Carousel.css";
import { BsArrowLeftCircleFill, BsArrowRightCircleFill } from "react-icons/bs";

// eslint-disable-next-line react/prop-types
function Carousel({ data }) {
  const [slide, setSlide] = useState(0);

  const nextSlide = () => {
    // eslint-disable-next-line react/prop-types
    setSlide(slide === data.length - 1 ? 0 : slide + 1);
  };

  const prevSlide = () => {
    // eslint-disable-next-line react/prop-types
    setSlide(slide === 0 ? data.length - 1 : slide - 1);
  };

  useEffect(() => {
    const intervalId = setInterval(() => {
      // eslint-disable-next-line react/prop-types
      if (slide === data.length - 1) {
        setSlide(0);
      } else {
        setSlide(slide + 1);
      }
    }, 5000);

    return () => clearInterval(intervalId);
  });

  return (
    <div className="carousel">
      {/* eslint-disable-next-line react/prop-types */}
      <div className="carousel-images">
        {/* eslint-disable-next-line react/prop-types */}
        {data.map((item, idx) => {
          return (
            <img
              src={item.src}
              alt={item.alt}
              key={idx}
              className={slide === idx ? "slide" : "slide-hidden"}
            />
          );
        })}
      </div>
      <BsArrowLeftCircleFill className="arrow arrow-left" onClick={prevSlide} />
      <BsArrowRightCircleFill
        className="arrow arrow-right"
        onClick={nextSlide}
      />
      <span className="indicators">
        {/* eslint-disable-next-line react/prop-types */}
        {data.map((_, idx) => {
          return (
            <button
              key={idx}
              onClick={() => setSlide(idx)}
              className={
                slide === idx ? "indicator" : "indicator indicator-inactive"
              }
            ></button>
          );
        })}
      </span>
    </div>
  );
}

export default Carousel;
