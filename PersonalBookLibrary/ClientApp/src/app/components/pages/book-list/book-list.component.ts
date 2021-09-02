import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.bookService.getBooks().subscribe(books => {
      this.books = books;
    });
  }

  onDeleteBook(id: string) {
    this.bookService.deleteBookById(id).subscribe(deletedBook => {
      this.books = this.books.filter(b => b.id !== deletedBook.id);
    });
  }
}
