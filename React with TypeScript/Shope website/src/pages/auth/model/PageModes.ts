export const PageModes = {
    signIn: "signIn",
    signUp: "signUp",
    profile: "profile",
    forgotPassword: "forgotPassword",
} as const;

export type PageMode =
    (typeof PageModes)[keyof typeof PageModes];