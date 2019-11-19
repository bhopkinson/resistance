import { Observable, BehaviorSubject } from "rxjs";

export class Utils {
    static convertObservableToBehaviorSubject<T>(observable: Observable<T>, initValue: T): BehaviorSubject<T> {
        const subject = new BehaviorSubject(initValue);
    
        observable.subscribe({
            complete: () => subject.complete(),
            error: x => subject.error(x),
            next: x => subject.next(x)
        });
    
        return subject;
    }
}
