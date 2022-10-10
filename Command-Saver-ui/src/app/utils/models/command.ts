import { platform } from './platform';

export interface command {
  id: number;
  goal: string;
  line: string;
  platforms: platform[];
}
