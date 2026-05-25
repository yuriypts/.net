import { ApplicationConfig, provideBrowserGlobalErrorListeners, inject } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideApollo } from 'apollo-angular';
import { HttpLink } from 'apollo-angular/http';
import { ApolloClient, InMemoryCache } from '@apollo/client/core';
import { environment } from '../environments/environment';

const createApolloClientOptions = (): ApolloClient.Options => {
  const httpLink = inject(HttpLink);

  return {
    link: httpLink.create({
      uri: environment.apirl,
    }),
    cache: new InMemoryCache(),
  };
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideClientHydration(withEventReplay()),
    provideHttpClient(),
    provideApollo(createApolloClientOptions),
  ],
};
