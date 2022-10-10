import { command } from './command';

export interface platform {
  id: number;
  name: string;
  commands: command[];
}
