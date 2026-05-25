import { Component, signal } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { UserResponse } from './user-response';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

const gqlMutation = gql`
  mutation UserMutation($name: String!) {
    createUser(name: $name, age: 10) {
      id
      name
      age
    }
  }
`;

@Component({
  selector: 'app-user',
  imports: [FormsModule, CommonModule],
  standalone: true,
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  public nameMutation= signal('');
  public mutationResult = signal<UserResponse>({ data: { createUser: { id: 0, name: '', age: 0 } } });

  constructor(private apollo: Apollo) {}

  changeMutation() {
      this.apollo.mutate({
        mutation: gqlMutation,
        variables: {
          name: this.nameMutation()
        }
      }).subscribe(result => {
        console.log('Apollo: GraphQL Mutation Result:', result);
        this.mutationResult.set(result as UserResponse);
      });
  }
}
