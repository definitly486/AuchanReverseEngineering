.class final Lcom/google/android/gms/internal/common/zzai;
.super Lcom/google/android/gms/internal/common/zzaj;
.source "com.google.android.gms:play-services-basement@@18.7.1"


# instance fields
.field final transient zza:I

.field final transient zzb:I

.field final synthetic zzc:Lcom/google/android/gms/internal/common/zzaj;


# direct methods
.method constructor <init>(Lcom/google/android/gms/internal/common/zzaj;II)V
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    iput-object p1, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    invoke-direct {p0}, Lcom/google/android/gms/internal/common/zzaj;-><init>()V

    iput p2, p0, Lcom/google/android/gms/internal/common/zzai;->zza:I

    iput p3, p0, Lcom/google/android/gms/internal/common/zzai;->zzb:I

    return-void
.end method


# virtual methods
.method public final get(I)Ljava/lang/Object;
    .locals 2

    .line 1
    iget v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzb:I

    const-string v1, "index"

    invoke-static {p1, v0, v1}, Lcom/google/android/gms/internal/common/zzt;->zzb(IILjava/lang/String;)I

    iget-object v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    iget v1, p0, Lcom/google/android/gms/internal/common/zzai;->zza:I

    add-int/2addr p1, v1

    .line 2
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final size()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzb:I

    return v0
.end method

.method public final bridge synthetic subList(II)Ljava/util/List;
    .locals 0

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/google/android/gms/internal/common/zzaj;->zzi(II)Lcom/google/android/gms/internal/common/zzaj;

    move-result-object p1

    return-object p1
.end method

.method final zzb()[Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    invoke-virtual {v0}, Lcom/google/android/gms/internal/common/zzae;->zzb()[Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method final zzc()I
    .locals 2

    .line 1
    iget-object v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    invoke-virtual {v0}, Lcom/google/android/gms/internal/common/zzae;->zzc()I

    move-result v0

    iget v1, p0, Lcom/google/android/gms/internal/common/zzai;->zza:I

    add-int/2addr v0, v1

    return v0
.end method

.method final zzd()I
    .locals 2

    .line 1
    iget-object v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    invoke-virtual {v0}, Lcom/google/android/gms/internal/common/zzae;->zzc()I

    move-result v0

    iget v1, p0, Lcom/google/android/gms/internal/common/zzai;->zza:I

    add-int/2addr v0, v1

    iget v1, p0, Lcom/google/android/gms/internal/common/zzai;->zzb:I

    add-int/2addr v0, v1

    return v0
.end method

.method final zzf()Z
    .locals 1

    .line 0
    const/4 v0, 0x1

    return v0
.end method

.method public final zzi(II)Lcom/google/android/gms/internal/common/zzaj;
    .locals 2

    .line 1
    iget v0, p0, Lcom/google/android/gms/internal/common/zzai;->zzb:I

    invoke-static {p1, p2, v0}, Lcom/google/android/gms/internal/common/zzt;->zzd(III)V

    iget v0, p0, Lcom/google/android/gms/internal/common/zzai;->zza:I

    iget-object v1, p0, Lcom/google/android/gms/internal/common/zzai;->zzc:Lcom/google/android/gms/internal/common/zzaj;

    add-int/2addr p1, v0

    add-int/2addr p2, v0

    .line 2
    invoke-virtual {v1, p1, p2}, Lcom/google/android/gms/internal/common/zzaj;->zzi(II)Lcom/google/android/gms/internal/common/zzaj;

    move-result-object p1

    return-object p1
.end method
