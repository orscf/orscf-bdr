export declare class BdrConnector {
    private rootUrlResolver;
    private apiTokenResolver;
    private httpPostMethod;
    private axiosHttpApi?;
    constructor(rootUrlResolver: () => string, apiTokenResolver: () => string, httpPostMethod: (url: string, requestObject: any, apiToken: string) => Promise<any>);
    private getRootUrl;
}
//# sourceMappingURL=connector.d.ts.map