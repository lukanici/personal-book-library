import { Author, BookGenre } from '.';

export interface Book {
  id: number;
  title: string;
  description: string;
  genre: BookGenre;
  author: Author;
  modifiedUtc: string;
}
