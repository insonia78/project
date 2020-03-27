import gql from 'graphql-tag';

export const appContext = gql`
    query appContext {
        appContext @client {
            context
        }
    }
`;

export const updateAppContext = gql`
    mutation updateAppContext($context: string) {
        updateAppContext(context: $context) @client
    }
`;
