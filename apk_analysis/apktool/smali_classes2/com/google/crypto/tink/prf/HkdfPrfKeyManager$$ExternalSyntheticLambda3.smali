.class public final synthetic Lcom/google/crypto/tink/prf/HkdfPrfKeyManager$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/crypto/tink/internal/MutableKeyCreationRegistry$KeyCreator;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final createKey(Lcom/google/crypto/tink/Parameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/Key;
    .locals 0

    .line 0
    check-cast p1, Lcom/google/crypto/tink/prf/HkdfPrfParameters;

    invoke-static {p1, p2}, Lcom/google/crypto/tink/prf/HkdfPrfKeyManager;->$r8$lambda$YaDNRj3ABt4eWI8Mhc4Zv9biqaA(Lcom/google/crypto/tink/prf/HkdfPrfParameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/prf/HkdfPrfKey;

    move-result-object p1

    return-object p1
.end method
