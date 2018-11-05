const BASE_URL = 'http://localhost:4792';

const providers: any[] = [
  { provide: 'environment', useValue: 'Development' },
  { provide: 'baseUrl', useValue: BASE_URL }
];

export const ENV_PROVIDERS = providers;

export const environment = {
  production: false,
  baseUrl: BASE_URL
};
