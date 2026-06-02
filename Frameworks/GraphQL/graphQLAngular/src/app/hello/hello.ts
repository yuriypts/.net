import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { Apollo, gql } from "apollo-angular";
import { ReturnHello } from './return-hello';

const query = {
  "query": "query Test($name: String! = \"Q\") {\r\n  hello(name: $name)\r\n  sumNumbers(value1: 1, value2: 3)\r\n}\r\n",
  "variables": {
    "name": "Test"
  }
};

const correctQuery = `
    query Test {
      hello(name: "Yuriy")
      sumNumbers(value1: 1, value2: 5)
  }
`

// Apollo recommends using the gql tag to parse GraphQL queries into a document that can be sent to the server.
const gqlQuery = gql`
  query Test($name: String! = "Q") {
    hello(name: $name),
    sumNumbers(value1: 1, value2: 5)
  }`;

@Component({
  selector: 'app-hello',
  imports: [FormsModule, CommonModule],
  standalone: true,
  templateUrl: './hello.html',
  styleUrl: './hello.css',
})
export class Hello {
  public helloResult = signal('Test');
  public sumNumbersResult = signal(0);
  public name: string = 'test';

  constructor(private http: HttpClient, private apollo: Apollo) {}

  getApolloHello() {
    const body = {
      query: gqlQuery,
      variables: {
        name: this.name
      }
    }; 
    this.apollo.query<any>(body).subscribe(result => {
      console.log('Apollo: GraphQL Query Result:', result);
      this.helloResult.set(result.data.hello);
      this.sumNumbersResult.set(result.data.sumNumbers);
    });
  }

  getHtppHello() {
    const body = {
      query: correctQuery
    }; 
    this.http.post<ReturnHello>(environment.apirl, body).subscribe(result => {
      console.log('HttpClient: GraphQL Query Result:', result);
      this.helloResult.set(result.data.hello);
      this.sumNumbersResult.set(result.data.sumNumbers);
    });
  }
}
