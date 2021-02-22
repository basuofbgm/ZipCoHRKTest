import Axios from "axios"

export type Guest = {
  id: string;
  firstName: string;
  lastName: string;
  created: string;
};

export type RandompicturesGalleries = {
  fileSize: string;
  pictureurl: string;
};
const api = Axios.create({
  baseURL: "http://localhost:5000/api/",
});

export const getGuests = async (): Promise<Guest[]> => {
  const resp = await api.get("/guests");
  return resp.data as Guest[];
};


export const createGuest = async (
  firstName: string,
  lastName: string
): Promise<void> => {
  await api.post("/guests", {
    firstName,
    lastName,
  });

};

export const getImages = async (): Promise<RandompicturesGalleries[]> => {
  const resp = await api.get("/RandomDogsGallery");
  return resp.data as RandompicturesGalleries[];
};

export const RefreshRandomDogpictures = async (): Promise<RandompicturesGalleries[]> => {
  const resp = await api.get("/RandomDogsGallery/RefreshRandomDogpictures");
  return resp.data as RandompicturesGalleries[];
};
