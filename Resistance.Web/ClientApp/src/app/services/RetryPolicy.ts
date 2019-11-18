import { IRetryPolicy } from "@microsoft/signalr";

export class RetryPolicy implements IRetryPolicy {
    nextRetryDelayInMilliseconds(retryContext: import("@microsoft/signalr").RetryContext): number {
        if (retryContext.elapsedMilliseconds < 90000) {
            console.log("retry " + retryContext.previousRetryCount + 1);
            return 1000;
        }
    }
}