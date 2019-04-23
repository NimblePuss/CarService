import { Car } from './car';
import { Person } from './person';
import { Service } from './service';

export class NewOrder {
    public Id: Number;
    public dateFrom: string;
    public dateTo: string;
    public orderDateCreate: Date;
    public message: string;

    public Car: Car;
    public Person: Person;
    public Services: Array<Service>;
}
