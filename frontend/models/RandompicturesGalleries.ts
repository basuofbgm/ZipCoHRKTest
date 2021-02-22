import Axios from "axios"
export type RandompicturesGalleries = {
  fileSize: string;
  pictureurl: string;
};
const api = Axios.create({
  baseURL: "http://localhost:5000/",
});

export const getrandompictures = async (): Promise<RandompicturesGalleries[]> => {
  const resp = await api.get("RandomDogsGallery");
  return resp.data as RandompicturesGalleries[];
};
