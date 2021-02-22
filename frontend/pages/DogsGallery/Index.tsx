import Layout from "../../components/Layout";
import { RandompicturesGalleries } from "../../models/guests";
//import React, { Component } from 'react';
import { getImages, RefreshRandomDogpictures } from "../../models/guests";
import ReactPlayer from 'react-player'
import styled from "styled-components";
import { FormEvent, useState } from "react"; 
import { flashError } from "../../utils";

const SubmitButton = styled.input`
  background-color: #090;
  color: #fff;
  border: none;
  padding: 0.5rem 1rem;
`;

const RandomImages = () => {
  const [randomImage, setRandomImage] = useState<RandompicturesGalleries[]>([]);
  const loadRandompics = async () => {
    try {
      const items = await getImages();
      setRandomImage(items);
    }
    catch (e) {
      flashError(e);
    }
  };
  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await RefreshRandomDogpictures();
    } catch (e) {
      flashError(e);
    }
    await loadRandompics();
  };
  return (
    <Layout title="DogsGallery">
      <h1>RandomDogsGallery</h1>
      <div>
        <form onSubmit={handleSubmit}>
          <SubmitButton type="submit" value="Refresh Image Gallery" />
        </form>
        {randomImage.map((i) => ( 
          <div className="row" style={{ margin: '5px' }} >
            <div className="col-md-3 col-sm-3">           
              {i.pictureurl.endsWith('.mp4') && <ReactPlayer url={i.pictureurl} alt="thumb" style={{ width: '25rem', padding: '5px' }} controls={true} /> }              
              {!i.pictureurl.endsWith('mp4') && <img src={i.pictureurl} alt="thumb" style={{ width: '30rem' }} />}             
            </div>
          </div>
        ))}
      </div>
    </Layout>
  );
}
export default RandomImages;

