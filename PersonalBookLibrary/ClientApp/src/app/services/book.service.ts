import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>('/api/books', httpOptions);
  }

  getBookById(id: string): Observable<Book> {
    return this.http.get<Book>(`/api/books/${id}`, httpOptions);
  }

  deleteBookById(id: string): Observable<Book> {
    return this.http.delete<Book>(`/api/books/${id}`, httpOptions);
  }

  createBook(book: Book) {
    return this.http.post(`/api/books`, book, httpOptions);
  }

  updateBook(id: string, book: Book) {
    return this.http.put<Book>(`/api/books/${id}`, book, httpOptions);
  }

}
