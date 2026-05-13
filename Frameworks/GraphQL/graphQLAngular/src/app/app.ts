import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { gql } from "apollo-angular";

const AUTHORS = gql`query Query {

}`;

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('graphQLAngular');
}
