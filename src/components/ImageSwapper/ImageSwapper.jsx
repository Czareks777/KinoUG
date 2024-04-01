import {useEffect, useState} from "react";

const images = ["hits/civilwar.jpg", "hits/godzilla.jpg", "newfilms/new1.jpg", "newfilms/new2.jpg"];

export default function ImageSwapper() {
    const [currentIndex, setCurrentIndex] = useState(0)

    useEffect(() => {
        const intervalId = setInterval(() => {
            if(currentIndex === images.length - 1) {
                setCurrentIndex(0);
            }
            else {
                setCurrentIndex(currentIndex + 1);
            }
        }, 3000)

        return () => clearInterval(intervalId);
    }, [currentIndex])

    return (
        <div>
            <img src={images[currentIndex]} />
        </div>
    )
}