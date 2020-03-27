import { Resource } from './resource.interface';

export interface CreateAuthor{
      success: boolean;
      data: Author;
}

export interface Author extends Resource{
    name: string;

}
