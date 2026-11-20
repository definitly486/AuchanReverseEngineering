.class public Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;
.super Ljava/lang/Object;
.source "ServerCertificateCustomValidator_TrustManager_FakeSSLSession.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Ljavax/net/ssl/SSLSession;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Xamarin.Android.Net.ServerCertificateCustomValidator+TrustManager+FakeSSLSession, Mono.Android"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>([Ljava/security/cert/X509Certificate;)V
    .locals 2

    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;

    if-ne v0, v1, :cond_0

    .line 23
    const-string v0, "Java.Security.Cert.X509Certificate[], Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Xamarin.Android.Net.ServerCertificateCustomValidator+TrustManager+FakeSSLSession, Mono.Android"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getApplicationBufferSize()I
.end method

.method private native n_getCipherSuite()Ljava/lang/String;
.end method

.method private native n_getCreationTime()J
.end method

.method private native n_getId()[B
.end method

.method private native n_getLastAccessedTime()J
.end method

.method private native n_getLocalCertificates()[Ljava/security/cert/Certificate;
.end method

.method private native n_getLocalPrincipal()Ljava/security/Principal;
.end method

.method private native n_getPacketBufferSize()I
.end method

.method private native n_getPeerCertificateChain()[Ljavax/security/cert/X509Certificate;
.end method

.method private native n_getPeerCertificates()[Ljava/security/cert/Certificate;
.end method

.method private native n_getPeerHost()Ljava/lang/String;
.end method

.method private native n_getPeerPort()I
.end method

.method private native n_getPeerPrincipal()Ljava/security/Principal;
.end method

.method private native n_getProtocol()Ljava/lang/String;
.end method

.method private native n_getSessionContext()Ljavax/net/ssl/SSLSessionContext;
.end method

.method private native n_getValue(Ljava/lang/String;)Ljava/lang/Object;
.end method

.method private native n_getValueNames()[Ljava/lang/String;
.end method

.method private native n_invalidate()V
.end method

.method private native n_isValid()Z
.end method

.method private native n_putValue(Ljava/lang/String;Ljava/lang/Object;)V
.end method

.method private native n_removeValue(Ljava/lang/String;)V
.end method


# virtual methods
.method public getApplicationBufferSize()I
    .locals 1

    .line 29
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getApplicationBufferSize()I

    move-result v0

    return v0
.end method

.method public getCipherSuite()Ljava/lang/String;
    .locals 1

    .line 36
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getCipherSuite()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getCreationTime()J
    .locals 2

    .line 43
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getCreationTime()J

    move-result-wide v0

    return-wide v0
.end method

.method public getId()[B
    .locals 1

    .line 113
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getId()[B

    move-result-object v0

    return-object v0
.end method

.method public getLastAccessedTime()J
    .locals 2

    .line 57
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getLastAccessedTime()J

    move-result-wide v0

    return-wide v0
.end method

.method public getLocalCertificates()[Ljava/security/cert/Certificate;
    .locals 1

    .line 120
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getLocalCertificates()[Ljava/security/cert/Certificate;

    move-result-object v0

    return-object v0
.end method

.method public getLocalPrincipal()Ljava/security/Principal;
    .locals 1

    .line 64
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getLocalPrincipal()Ljava/security/Principal;

    move-result-object v0

    return-object v0
.end method

.method public getPacketBufferSize()I
    .locals 1

    .line 71
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPacketBufferSize()I

    move-result v0

    return v0
.end method

.method public getPeerCertificateChain()[Ljavax/security/cert/X509Certificate;
    .locals 1

    .line 127
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPeerCertificateChain()[Ljavax/security/cert/X509Certificate;

    move-result-object v0

    return-object v0
.end method

.method public getPeerCertificates()[Ljava/security/cert/Certificate;
    .locals 1

    .line 134
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPeerCertificates()[Ljava/security/cert/Certificate;

    move-result-object v0

    return-object v0
.end method

.method public getPeerHost()Ljava/lang/String;
    .locals 1

    .line 78
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPeerHost()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPeerPort()I
    .locals 1

    .line 85
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPeerPort()I

    move-result v0

    return v0
.end method

.method public getPeerPrincipal()Ljava/security/Principal;
    .locals 1

    .line 92
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getPeerPrincipal()Ljava/security/Principal;

    move-result-object v0

    return-object v0
.end method

.method public getProtocol()Ljava/lang/String;
    .locals 1

    .line 99
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getProtocol()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getSessionContext()Ljavax/net/ssl/SSLSessionContext;
    .locals 1

    .line 106
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getSessionContext()Ljavax/net/ssl/SSLSessionContext;

    move-result-object v0

    return-object v0
.end method

.method public getValue(Ljava/lang/String;)Ljava/lang/Object;
    .locals 0

    .line 141
    invoke-direct {p0, p1}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getValue(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public getValueNames()[Ljava/lang/String;
    .locals 1

    .line 148
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_getValueNames()[Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public invalidate()V
    .locals 0

    .line 155
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_invalidate()V

    return-void
.end method

.method public isValid()Z
    .locals 1

    .line 50
    invoke-direct {p0}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_isValid()Z

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 177
    iget-object v0, p0, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 178
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->refList:Ljava/util/ArrayList;

    .line 179
    :cond_0
    iget-object v0, p0, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 184
    iget-object v0, p0, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 185
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public putValue(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 0

    .line 162
    invoke-direct {p0, p1, p2}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_putValue(Ljava/lang/String;Ljava/lang/Object;)V

    return-void
.end method

.method public removeValue(Ljava/lang/String;)V
    .locals 0

    .line 169
    invoke-direct {p0, p1}, Lxamarin/android/net/ServerCertificateCustomValidator_TrustManager_FakeSSLSession;->n_removeValue(Ljava/lang/String;)V

    return-void
.end method
