import React from 'react';
import { render, fireEvent } from '@testing-library/react';
import 'mutationobserver-shim';
import {FindOccurrences} from "../components";
import {OccurrencesScreen} from "../screens";

test('should render header', () => {
  const { container } = render(<OccurrencesScreen />);
  const header = container.querySelector("h1");
  expect(header!.textContent).toBe('Web Scraper');
});
