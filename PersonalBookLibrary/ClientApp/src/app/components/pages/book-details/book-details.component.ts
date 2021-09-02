import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { zip } from 'rxjs';
import { Author, Book, BookGenre } from 'src/app/models';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html'
})
export class BookDetailsComponent {
  form: FormGroup;
  id: string;
  isAddMode: boolean;
  genres = BookGenre;
  authors: Author[];
  isDataLoaded: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService,
    private authorService: AuthorService,
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    if (this.isAddMode) {
      this.authorService.getAuthors().subscribe(authors => this.loadData(authors));
    } else {
      zip(
        this.authorService.getAuthors(),
        this.bookService.getBookById(this.id)
      ).subscribe(([ authors, book ]) => this.loadData(authors, book));
    }
  }

  private loadData(authors: Author[], book?: Book) {
    this.authors = authors;
    this.form = this.formBuilder.group({
      title: [''],
      description: [''],
      genre: [BookGenre[0]],
      authorId: [this.authors[0].id],
    });
    if (book) {
      this.form.patchValue(<Book>{
        ...book,
        authorId: book.author.id
      });
    }
    this.isDataLoaded = true;
  }

  onSubmit() {
    if (this.isAddMode) {
      this.bookService.createBook(this.form.value).subscribe(() => {
        this.router.navigate(['']);
      });
    } else {
      this.bookService.updateBook(this.id, this.form.value).subscribe(() => {
        this.router.navigate(['']);
      });
    }
  }
}
