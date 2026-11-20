.class public final Lcom/google/android/gms/common/api/ApiMetadata$Builder;
.super Ljava/lang/Object;
.source "com.google.android.gms:play-services-basement@@18.7.1"


# annotations
.annotation build Lcom/google/android/gms/common/annotation/KeepForSdk;
.end annotation

.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/android/gms/common/api/ApiMetadata;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation


# instance fields
.field private zza:Lcom/google/android/gms/common/api/ComplianceOptions;

.field private zzb:Z


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public build()Lcom/google/android/gms/common/api/ApiMetadata;
    .locals 2
    .annotation build Lcom/google/android/gms/common/annotation/KeepForSdk;
    .end annotation

    .line 1
    new-instance v0, Lcom/google/android/gms/common/api/ApiMetadata;

    iget-object v1, p0, Lcom/google/android/gms/common/api/ApiMetadata$Builder;->zza:Lcom/google/android/gms/common/api/ComplianceOptions;

    invoke-direct {v0, v1}, Lcom/google/android/gms/common/api/ApiMetadata;-><init>(Lcom/google/android/gms/common/api/ComplianceOptions;)V

    iget-boolean v1, p0, Lcom/google/android/gms/common/api/ApiMetadata$Builder;->zzb:Z

    .line 2
    invoke-virtual {v0, v1}, Lcom/google/android/gms/common/api/ApiMetadata;->zza(Z)V

    return-object v0
.end method

.method public setComplianceOptions(Lcom/google/android/gms/common/api/ComplianceOptions;)Lcom/google/android/gms/common/api/ApiMetadata$Builder;
    .locals 0
    .annotation build Lcom/google/android/gms/common/annotation/KeepForSdk;
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/google/android/gms/common/api/ApiMetadata$Builder;->zza:Lcom/google/android/gms/common/api/ComplianceOptions;

    return-object p0
.end method

.method final synthetic zza(Z)Lcom/google/android/gms/common/api/ApiMetadata$Builder;
    .locals 0

    .line 0
    const/4 p1, 0x1

    iput-boolean p1, p0, Lcom/google/android/gms/common/api/ApiMetadata$Builder;->zzb:Z

    return-object p0
.end method
